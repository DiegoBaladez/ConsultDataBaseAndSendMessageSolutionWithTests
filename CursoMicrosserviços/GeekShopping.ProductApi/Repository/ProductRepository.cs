using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _context;
        private IMapper _mapper;

        public ProductRepository(SqlServerContext context, IMapper mapper)
        {
            _context= context;
            _mapper = mapper;
        }
        
        public async Task<ProductVO> Create(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);

            //adicionar o novo product no contexto (na memória) depois faz a  persistência com o SaveChangesAsync
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var productVo = await FindByID(id);
                if (productVo == null) return false;

                _context.Products.Remove(_mapper.Map<Product>(productVo));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindByID(long id)
        {
            //Lembrete... esse _context.Products é literalmente a tabela Products na memória. Aí usamos o LINQ para fazer a consulta...
            var product = await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync() ;

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);

            //adicionar o novo product no contexto (na memória) depois faz a  persistência com o SaveChangesAsync
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }
    }
}
