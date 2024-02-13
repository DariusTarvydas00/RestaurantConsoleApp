using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace DataAccess.Repositories.ModelRepositories;

public class TableRepository() : BaseRepository<TableEntity>(@"C:\\Restaurant\\table.json"), ITableRepository;