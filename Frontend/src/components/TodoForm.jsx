import { useState } from 'react'

function TodoForm({ onAddTodo }) {
    const [title, setTitle] = useState('')
    const [description, setDescription] = useState('')

    const handleSubmit = (e) => {
        e.preventDefault()
        if (title.trim()) {
            onAddTodo(title.trim(),description.trim() || null)
            setTitle('')
            setDescription('')
        }
    }

    return (
        <form onSubmit={handleSubmit} className="mb-6">
            <div className="space-y-3">
                <input
                type="text"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                placeholder="Whats on your mind?"
                className="w-full px-4 py-3 border-0 rounded-xl focus:outline-none focus:ring-3 focus:ring-purple-300 bg-white/80 text-gray-800 placeholder-gray-500 font-medium shadow-sm"
                />

                <textarea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    placeholder="Any specific details? (optional)..."
                    rows="2"
                    className="w-full px-4 py-3 border-0 rounded-xl focus:outline-none focus:ring-3 focus:ring-purple-300 bg-white/80 text-gray-800 placeholder-grey-500 resize-none font-medium shadow-sm"
                />
                <button
                    type="submit"
                    className="w-full px-4 py-3 bg-green-300 text-black rounded-xl hover:bg-green-400 focus:outline-none focus:ring-3 focus:ring-green-200 font-semibold shadow-md transition-all duration-200"
                >
                    Add task
                </button>
            </div>
        </form>
    )
}

export default TodoForm