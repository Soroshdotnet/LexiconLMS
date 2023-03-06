using LexiconLMS.Server.Data;
using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Services
{
    public class ModulesRepository : IModulesRepository
    {
        private ApplicationDbContext db;

        public ModulesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Module module)
        {
            db.Modules.Add(module);
        }

        public void Remove(Module module)
        {
            db.Modules.Remove(module);

        }
        public bool ModuleExists(int id)
        {
            return (db.Modules?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}