using Radigate.Server.Templates.Data;

namespace Radigate.Server.Templates.Services {
    public class TemplateService : ITemplateService {
        private readonly TemplatesDataContext _context;

        public TemplateService(TemplatesDataContext context) {
            _context = context;
        }

        public async Task<ServiceResponse<bool>> AddGroupTemplateAsync(NewGroupTemplate newTemplate) {
            var group = new GroupTemplate(newTemplate);
            await _context.GroupTemplates.AddAsync(group);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>();
        }

        public async Task<ServiceResponse<bool>> AddPatientTemplateAsync(NewPatientTemplate newTemplate) {
            var template = new PatientTemplate(newTemplate);
            await _context.PatientTemplates.AddAsync(template);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>();
        }

        public async Task<ServiceResponse<List<GroupTemplate>>> GetAllGroupTemplatesAsync() {
            var response = new ServiceResponse<List<GroupTemplate>> {
                Data = await _context.GroupTemplates
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<PatientTemplate>>> GetAllPatientTemplatesAsync() {
            var response = new ServiceResponse<List<PatientTemplate>> {
                Data = await _context.PatientTemplates
                    .Include(t => t.GroupTemplates )
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<GroupTemplate>> GetGroupTemplateAsync(int templateId) {
            var result = await _context.GroupTemplates.FindAsync(templateId);

            if (result is null) return new ServiceResponse<GroupTemplate> { Success = false, Message = "Group Template does not exist." };
            return new ServiceResponse<GroupTemplate> { Data = result };
        }

        public async Task<ServiceResponse<PatientTemplate>> GetPatientTemplateAsync(int templateId) {
            var result = await _context.PatientTemplates
                .Include(p => p.GroupTemplates)
                .FirstOrDefaultAsync(p => p.Id == templateId);

            if (result is null) return new ServiceResponse<PatientTemplate> { Success = false, Message = "Patient Template does not exist." };
            return new ServiceResponse<PatientTemplate> { Data = result };
        }

        public async Task<ServiceResponse<bool>> RemoveGroupTemplateAsync(int templateId) {
            var result = await _context.GroupTemplates
                .FirstOrDefaultAsync(p => p.Id == templateId);

            if (result is null) return new ServiceResponse<bool> { Success = false, Message = "Group Template does not exist." };

            _context.GroupTemplates.Remove(result);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemovePatientTemplateAsync(int templateId) {
            var result = await _context.PatientTemplates
                .Include(p => p.GroupTemplates)
                .FirstOrDefaultAsync(p => p.Id == templateId);

            if (result is null) return new ServiceResponse<bool> { Success = false, Message = "Patient Template does not exist." };

            _context.PatientTemplates.Remove(result);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<GroupTemplate>> UpdateGroupTemplate(GroupTemplate updatedTemplate) {
            var result = await _context.GroupTemplates.FindAsync(updatedTemplate.Id);

            if (result is null) return new ServiceResponse<GroupTemplate> { Success = false, Message = "Group Template does not exist." };

            result = updatedTemplate;
            await _context.SaveChangesAsync();

            return new ServiceResponse<GroupTemplate> { Data = result };
        }

        public async Task<ServiceResponse<PatientTemplate>> UpdatePatientTemplate(PatientTemplate updatedTemplate) {
            var result = await _context.PatientTemplates
                .Include(p => p.GroupTemplates)
                .FirstOrDefaultAsync(p => p.Id == updatedTemplate.Id);

            if (result is null) return new ServiceResponse<PatientTemplate> { Success = false, Message = "Patient Template does not exist." };

            result = updatedTemplate;
            await _context.SaveChangesAsync();

            return new ServiceResponse<PatientTemplate> { Data = result };
        }
    }
}
