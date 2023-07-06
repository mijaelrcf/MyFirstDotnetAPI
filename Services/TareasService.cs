using MyFirstDotnetAPI.Models;

namespace MyFirstDotnetAPI.Services;
public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }
    
    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            //Tarea.Peso = Tarea.Peso;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();

    Task Save(Tarea tarea);

    Task Update(Guid id, Tarea tarea);

    Task Delete(Guid id);
}