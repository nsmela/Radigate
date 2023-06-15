using Radigate.Server.Data;
using Radigate.Server.Migrations;
using Radigate.Shared;
using System.Reflection.Emit;

namespace Radigate.Server.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly PatientDataContext _context;

        public PatientService(PatientDataContext context) {
            _context = context;
        }

        //https://www.youtube.com/watch?v=UBNRcaw1bDk
        public async Task<ServiceResponse<List<Patient>>> GetPatientsAsync() {
            var response = new ServiceResponse<List<Patient>> {
                Data = await _context.Patients
                    .Include(p => p.TaskGroups)
                    .ThenInclude(g => g.Tasks)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<int>>> GetPatientsIdAsync() {
            var response = new ServiceResponse<List<int>> {
                Data = await _context.Patients
                    .Select(Patient => Patient.Id) //grab only the id
                    .ToListAsync()
            };

            return response;
        }

        //https://learn.microsoft.com/en-us/ef/ef6/fundamentals/relationships
        public async Task<ServiceResponse<Patient>> GetPatientAsync(int patientId) {
            var response = new ServiceResponse<Patient>();

            var patient = await _context.Patients
                .Include(p => p.TaskGroups)
                .ThenInclude(g => g.Tasks)
                .FirstOrDefaultAsync(p => p.Id == patientId);
                

            if (patient is null) {
                response.Success = false;
                response.Message = "Patient is not found";
            }
            else {
                response.Data = patient;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdatePatientAsync(PatientValueItem patient) {
            var samePatient = await _context.Patients
                .Include(p => p.TaskGroups)
                .ThenInclude(g => g.Tasks)
                .FirstOrDefaultAsync(p => p.Id == patient.PatientId);

            if (samePatient is null) {
                return new ServiceResponse<bool> {
                    Data = false,
                    Success = false,
                    Message = $"Patient does not exist! (Id:{patient.PatientId}, Name:{patient.LastName + ", " + patient.FirstName})"
                };
            }

            //update the patient
            //patient info
            if(!String.IsNullOrEmpty(patient.FirstName)) samePatient.FirstName = patient.FirstName;
            if(!String.IsNullOrEmpty(patient.LastName)) samePatient.LastName = patient.LastName;
            if(!String.IsNullOrEmpty(patient.Identifier)) samePatient.Identifier = patient.Identifier;

            //group info
            var oldGroups = samePatient.TaskGroups;
            var newGroups = new List<TaskGroup>();

            //update existing group
            foreach(var newGroup in patient.Groups) {
                var taskGroup = samePatient.TaskGroups.FirstOrDefault(g => g.Id == newGroup.Id);
                if (taskGroup is null) continue;

                //group
                taskGroup.Label = newGroup.Label;
                taskGroup.SortingOrder = patient.Groups.IndexOf(newGroup);

                //tasks
                var oldTasks = new List<TaskItem>();
                foreach (var task in taskGroup.Tasks) oldTasks.Add(new TaskItem {Id = task.Id });

                //create, update or delete?
                foreach (var newTask in newGroup.Tasks) {
                    //create
                    if(newTask.Id is null) {
                        var task = new TaskItem {
                            Label = newTask.Label,
                            Value = newTask.Value,
                            Type = newTask.Type,
                            SortingOrder = newGroup.Tasks.IndexOf(newTask),
                            TaskGroup = taskGroup,
                            TaskGroupId = taskGroup.Id
                        };
                        taskGroup.Tasks.Add(task);
                        _context.Tasks.Add(task);
                        continue;
                    }

                    var oldTask = _context.Tasks.Find(newTask.Id);

                    //filters out tasks to be deleted
                    int index = oldTasks.FindIndex(t => t.Id == newTask.Id);
                    if ( index >= 0) oldTasks.RemoveAt(index);

                    //update
                    if (oldTask is not null) {
                        var task = new TaskItem {
                            Id = oldTask.Id,
                            TaskGroup = taskGroup,
                            TaskGroupId = taskGroup.Id,
                            Label = newTask.Label,
                            Value = newTask.Value,
                            Type = newTask.Type,
                            SortingOrder = newGroup.Tasks.IndexOf(newTask)
                        };
                        _context.Tasks.Entry(oldTask).CurrentValues.SetValues(task);
                        continue;
                    }
                }
                //delete tasks leftover from the filter from before
                foreach(var task in oldTasks) {
                    var entity = await _context.Tasks.FindAsync(task.Id);
                    if(entity is not null ) _context.Tasks.Remove(entity);
                }

                //save it
                _context.TaskGroups.Entry(samePatient.TaskGroups.First(g => g.Id == taskGroup.Id)).CurrentValues.SetValues(taskGroup);
            }

            //generate new groups and tasks
            foreach(var newGroup in patient.Groups) {
                var taskGroup = samePatient.TaskGroups.FirstOrDefault(g => g.Id == newGroup.Id);
                if (taskGroup is not null) continue;//group exists

                //group
                taskGroup = new TaskGroup {
                    Patient = samePatient,
                    PatientId = samePatient.Id,
                    Label = newGroup.Label,
                    SortingOrder = patient.Groups.IndexOf(newGroup)
                };

                //tasks
                var tasks = new List<TaskItem>();
                foreach(var task in newGroup.Tasks) {
                    var taskItem = new TaskItem {
                        Label = task.Label,
                        Value = task.Value,
                        Type = task.Type,
                        SortingOrder = newGroup.Tasks.IndexOf(task),
                        TaskGroup = taskGroup
                    };
                    tasks.Add(taskItem);
                }

                //save it
                taskGroup.Tasks = tasks;
                _context.TaskGroups.Add(taskGroup);
                samePatient.TaskGroups.Add(taskGroup);
            }

            //delete the group and all tasks within it
            //have to use a for loop, foreach faults because you're deleting the collection it's looping through
            for (int i = samePatient.TaskGroups.Count - 1; i >= 0; i--) { 
                var group = samePatient.TaskGroups.ElementAt(i);
                if (group is null || group.Id <= 0) continue;
                if (patient.Groups.Any(g => g.Id == group.Id)) continue;

                //delete tasks
                for(int j = group.Tasks.Count - 1; j >= 0; j--) {
                    var task = group.Tasks.ElementAt(j);
                    var entity = _context.Tasks.Find(task.Id);
                    if (entity is not null) _context.Tasks.Remove(entity);
                }

                //delete group
                samePatient.TaskGroups.Remove(group);
                var groupEntity = await _context.TaskGroups.FindAsync(group.Id);
                if(groupEntity is not null) _context.TaskGroups.Remove(groupEntity);
            }

            _context.Patients.Entry(samePatient).CurrentValues.SetValues(samePatient);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}
