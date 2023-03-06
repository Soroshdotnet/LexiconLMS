using LexiconLMS.Server.Models;

namespace LexiconLMS.Server.Services
{
    public interface IModulesRepository
    {
        void Add(Module module);
        bool ModuleExists(int id);
        void Remove(Module module);
    }
}