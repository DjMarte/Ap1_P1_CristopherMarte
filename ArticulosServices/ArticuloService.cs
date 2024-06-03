using Ap1_P1_CristopherMarte.DAL;
using Ap1_P1_CristopherMarte.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

namespace Ap1_P1_CristopherMarte.ArticulosServices;

public class ArticuloService
{
	private readonly Contexto _contexto;
    public ArticuloService(Contexto contexto){
        _contexto = contexto;
    }

    public async Task<bool> Guardar(Articulos articulo) {
        if(! await Existe(articulo.ArticuloId))
            return await Insertar(articulo);
        else
            return await Modificar(articulo);
    }

	private async Task<bool> Existe(int articuloId) {
		return await _contexto.Articulos
			.AnyAsync(a => a.ArticuloId == articuloId);
	}

	public async Task<bool> ExisteDescripcion(int articuloId, string descripcion) {
		return await _contexto.Articulos.AnyAsync(a => a.ArticuloId != articuloId 
		&& a.Descripcion.ToLower().Equals(descripcion.ToLower()));
	}

	private async Task<bool> Insertar(Articulos articulo) {
		_contexto.Articulos.Add(articulo);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Articulos articulo) {
		_contexto.Update(articulo);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(articulo).State = EntityState.Detached;
		return modificado;
	}

	public async Task<bool> Eliminar(Articulos articulo) {
		return await _contexto.Articulos
			.AsNoTracking()
			.Where(a => a.ArticuloId == articulo.ArticuloId)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<Articulos?> Buscar(int id) {
		return await _contexto.Articulos
			.AsNoTracking()
			.FirstOrDefaultAsync(a => a.ArticuloId == id);
	}

	public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio) {
		return await _contexto.Articulos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}

	public decimal CalcularVenta(decimal costo, int porcentajeGanancia) {
		decimal ganancia = costo * porcentajeGanancia / 100;
		return costo + ganancia;
	}
}