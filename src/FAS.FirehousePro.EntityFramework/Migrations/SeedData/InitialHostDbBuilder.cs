using FAS.FirehousePro.EntityFramework;
using EntityFramework.DynamicFilters;

namespace FAS.FirehousePro.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly FirehouseProDbContext _context;

        public InitialHostDbBuilder(FirehouseProDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
