using Radigate.Server.Data;

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
            var groups = new List<TaskGroup>();
            int groupIndex = 0;
            foreach(var group in patient.Groups) {
                var taskGroup = samePatient.TaskGroups.FirstOrDefault(g => g.Id == group.Id);

                //group is new
                if(taskGroup is null) {
                    taskGroup = new TaskGroup {
                        Label= group.Label,
                        Patient = samePatient,
                        PatientId = samePatient.Id
                    };

                    var tasks = new List<TaskItem>();
                    foreach (var task in group.Tasks) tasks.Add(new TaskItem {
                        Label = task.Label,
                        Value= task.Value,
                        Comments= task.Comments,
                        Type= task.Type,

                        TaskGroup = taskGroup,
                        SortingOrder = tasks.Count()
                    });

                    taskGroup.Tasks = tasks;
                    groups.Add(taskGroup);
                    groupIndex++;
                    continue;
                }

                //group exists in patient and record
                if(taskGroup is not null) {
                    taskGroup.Label = group.Label;
                    taskGroup.SortingOrder = groupIndex;
                    groupIndex++;

                    //edit tasks
                    var tasks = new List<TaskItem>();
                    int taskIndex = 0;
                    foreach(var task in group.Tasks) {
                        var taskItem = taskGroup.Tasks.FirstOrDefault(t => t.Id == task.Id);

                        //task is new
                        if (taskItem is null) {
                            taskItem = new TaskItem {
                                Label= task.Label,
                                Value = task.Value,
                                Comments = task.Comments,
                                Type = task.Type,

                                TaskGroup = taskGroup,
                                SortingOrder = taskIndex
                            };
                            taskIndex++;
                            tasks.Add(taskItem);
                            continue;
                        }

                        //if task exist
                        taskItem.SortingOrder = taskIndex;
                        taskIndex++;

                        taskItem.Label = task.Label;
                        taskItem.Value = task.Value;
                        taskItem.Type= task.Type;
                        taskItem.Comments = task.Comments;

                        tasks.Add(taskItem);

                        //remaining tasks are discarded
                    }

                    taskGroup.Tasks = tasks;
                    groups.Add(taskGroup);
                }
            }

            samePatient.TaskGroups = groups;
            
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}
