using DataAccess.Entities.SpecEntities;
using DataAccess.IRepositories;

namespace DataAccess.Repositories.ModelRepositories;

public class VoucherRepository() : BaseRepository<VoucherEntity>(@"C:\\Restaurant\\voucher.json"), IVoucherRepository;