using AutoMapper;

using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.Models.DTOs.Todo;

namespace LivingLab.Web.Services.Todo;

public class TodoService : ITodoService
{
    private readonly IMapper _mapper;
    private readonly ITodoRepository _todoRepository;
    
    public TodoService(IMapper mapper, ITodoRepository todoRepository)
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    public async Task<List<TodoDTO>>  GetAllTodosAsync()
    {
        var todos = await _todoRepository.GetAllAsync();
        return _mapper.Map<List<Core.Entities.Todo>, List<TodoDTO>>(todos);
    }

    public async Task<TodoDTO> GetTodoAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        return _mapper.Map<Core.Entities.Todo, TodoDTO>(todo);
    }

    public async Task<TodoDTO> CreateTodoAsync(CreateTodoDTO todo)
    {
        var newTodo = _mapper.Map<CreateTodoDTO, Core.Entities.Todo>(todo);

        var createdTodo = await _todoRepository.AddAsync(newTodo);

        return _mapper.Map<Core.Entities.Todo, TodoDTO>(createdTodo);
    }
}
