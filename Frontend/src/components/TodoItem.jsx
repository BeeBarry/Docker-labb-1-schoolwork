function TodoItem({ todo, onToggle, onDelete }) {
  return (
    <div className="flex items-center gap-3 p-4 bg-white rounded-xl shadow-sm border border-purple-200">
      <input
        type="checkbox"
        checked={!!todo.isDone}
        onChange={onToggle}
        className="w-4 h-4 text-blue-600 rounded focus:ring-blue-500"
      />
      <div className="flex-1">
        <div
          className={`font-medium ${
            todo.IsDone ? "line-through text-green-400" : "text-black"
          }`}
        >
          {todo.title}
        </div>
        {todo.description && (
          <div className="text-sm text-gray-500">{todo.description}</div>
        )}
      </div>
      <button
        onClick={onDelete}
        className="px-3 py-1.5 text-red-500 hover:bg-red-100 rounded-lg text-sm font-medium transition-colors"
      >
        Munch!
      </button>
    </div>
  );
}

export default TodoItem;
