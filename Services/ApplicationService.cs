using JobSearchApp.Data;
using JobSearchApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Services
{    
    public class ApplicationService
    {
        private readonly AppDbContext _context;
        private readonly NavigationManager _navManager;

        public ApplicationService(AppDbContext context, NavigationManager navManager)
        {
            _context = context;
            _navManager = navManager;
        }

        public async Task CheckUser(string userEmail, int applicationID)
        {
            var user = _context.Users.Where(x => x.Email == userEmail).Include(u => u.Applications).FirstOrDefault();

            bool verified = false;

            foreach(Application application in user.Applications)
            {
                if (application.ID == applicationID) 
                {
                    verified = true;
                    break;
                } 
            }

            if (!verified) _navManager.NavigateTo("/NoPermission");
        }

        public async Task<bool> CheckApplication(string url)
        {
            var application = _context.Applications.Where(a => a.URL == url).FirstOrDefault();

            if(application != null)return false;
            return true;
        }

        public async Task CreateApplicationAsync(Application application, string uesrEmail)
        {
            try
            {
                var user = await _context.Users.Where(u => u.Email == uesrEmail).FirstOrDefaultAsync();

                application.UserID = user.ID;

                _context.Applications.Add(application);
                await _context.SaveChangesAsync();

                

                _navManager.NavigateTo($"/Application/{application.ID}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            var application = _context.Applications.SingleOrDefault(a => a.ID == id);            

            return application;
        }

        public async Task UpdateApplication(Application application)
        {
            var applicationToUpdate = _context.Applications.SingleOrDefault(a => a.ID == application.ID);

            applicationToUpdate.URL = application.URL;
            applicationToUpdate.Category = application.Category;
            applicationToUpdate.Employer = application.Employer;
            applicationToUpdate.JobTitle = application.JobTitle;
            applicationToUpdate.HasApplied = application.HasApplied;
            applicationToUpdate.ApplicationDate = application.ApplicationDate;
            applicationToUpdate.HasInterviewed = application.HasInterviewed;
            applicationToUpdate.InterviewDate = application.InterviewDate;
            applicationToUpdate.Hired = application.Hired;
            applicationToUpdate.HireDate = application.HireDate;
            applicationToUpdate.Notes = application.Notes;
            applicationToUpdate.UserID = application.UserID;

            _context.Applications.Update(applicationToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplication(int id)
        {
            var applicationToDelete = _context.Applications.SingleOrDefault(a => a.ID == id);

            _context.Applications.Remove(applicationToDelete);
            await _context.SaveChangesAsync();

            _navManager.NavigateTo("/Applications");
        }

        public async Task<List<JobSearchApp.Models.Application>> GetApplications(string userEmail)
        {
            var applications = await _context.Applications.Include(u => u.User).Where(a => a.User.Email == userEmail).ToListAsync();

            return applications;
        }
    }
}
