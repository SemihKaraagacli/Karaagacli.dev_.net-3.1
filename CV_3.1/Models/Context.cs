using Microsoft.EntityFrameworkCore;

namespace CV_3._1.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7OMS01D; database=CV-3.1_DB; integrated security=true;");
        }

        public DbSet<PanelProfil> panelProfils { get; set; }
        public DbSet<PanelAbout> panelAbouts { get; set; }
        public DbSet<PanelEducation> panelEducations { get; set; }
        public DbSet<PanelExperiance> panelExperiances { get; set; }
        public DbSet<PanelProject> panelProjects { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}
