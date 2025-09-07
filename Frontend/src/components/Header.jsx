function Header() {
    return (
        <div className="text-center mb-8">
            <div className="flex justify-center mb-4">
                <img
                    src="/monster.svg"
                    alt="Very hungry looking fluffy cute but scary blue monster thats totally not real"
                    className="w-16 h-16"
                    />
            </div>
            <h1 className="text-3xl font-bold text-gray-800">Today list</h1>
            <p className="text-gray-600 mt-2"> A very hungry monster wants to munch on your delicious daily tasks</p>
        </div>
    )
}

export default Header