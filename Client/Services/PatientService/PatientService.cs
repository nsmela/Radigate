
namespace Radigate.Client.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly HttpClient _http;

        public List<Patient> Patients { get; set; } = new();

        public PatientService(HttpClient http) {
            _http = http;
        }

        //cannot deserialize the objects normally
        //https://www.puresourcecode.com/dotnet/csharp/derived-classes-with-system-text-json/
        public async Task GetPatients() {
            string requestString = $"/api/Patient";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Patient>>>(requestString);

            if (result is not null && result.Data is not null) {
                var patients = new List<Patient>();
                foreach(var patient in result.Data) {
                    patients.Add(ConvertPatient(patient));
                }
                Patients = patients;
                return;
            }

            Patients = new();
        }

        public async Task<ServiceResponse<Patient>> GetPatient(int patientId) {
            string requestString = $"/api/Patient/{patientId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<Patient>>(requestString);

            if(result is not null && result.Data is not null) 
                result.Data = ConvertPatient(result.Data);

            return result;
        }

        private Patient ConvertPatient(Patient patient) {
            foreach (var group in patient.TaskGroups) {
                var tasks = new List<TaskItem>();
                foreach (var task in group.Tasks) {
                    switch (task.Type) {
                        case (int)TaskType.Bool:
                            tasks.Add(new TaskBool(task));
                            break;
                        case (int)TaskType.Text:
                            tasks.Add(new TaskText(task));
                            break;
                        case (int)TaskType.Number:
                            tasks.Add(new TaskNumber(task));
                            break;
                        case (int)TaskType.List:
                            tasks.Add(new TaskList(task));
                            break;
                        default:
                            tasks.Add((TaskItem)task);
                            break;
                    }
                }
                group.Tasks = tasks;
            }
            return patient;
        }
    }

    //Task classes
    public class TaskBool : TaskItem {
        public bool Checked { get; set; }
        public TaskBool(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;

            Checked = task.Value == "true";
        }
    }

    public class TaskText : TaskItem {
        public string Text { get; set; }
        public TaskText(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;
            Value = task.Value;

            Text = task.Value;
        }
    }

    public class TaskNumber : TaskItem {
        public double Number { get; set; } = 0.0f;
        public TaskNumber(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;
            Value=task.Value;

            double number;
            if(double.TryParse(task.Value, out number)) Number = number;
        }
    }

    public class TaskList : TaskItem {
        public List<string> Options { get; set; } = new List<string>();
        public string SelectedOption { get; set; } = "No selection";
        public TaskList(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;

            if (string.IsNullOrEmpty(task.Value)) return;

            var options = task.Value.Split(',').ToList();
            int result = -1;
            if(int.TryParse(options[0], out result)) SelectedOption = options[result];
            options.RemoveAt(0);
            Options = options;

            Value = SelectedOption;
        }
    }

    public class TaskDate : TaskItem {
        public DateTime Date { get; set; } = new DateTime();
        public TaskDate(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;

            if (string.IsNullOrEmpty(task.Value)) return;

            var date = new DateTime();
            if (DateTime.TryParse(task.Value, out date)) Date = date;

        }
    }

    public class TaskCalculate : TaskItem {
        public string Formula { get; set; } = "no formula";
        public TaskCalculate(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;
            Value = task.Value;

            Formula = task.Value;
        }
    }
}

