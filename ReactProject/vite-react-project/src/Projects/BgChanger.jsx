import React, {useState} from 'react'
import '../TailwindAndProps/style.css'

function BgChanger(){
    const [color, setColor]=useState('black');
    return (
        <div className='w-full h-screen' style={{backgroundColor: color}}>
            <div className='flex-wrap justify-center gap-3 bg-white px-3 py-2 rounded-xl shadow-lg absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2'>
                <button onClick={() => setColor('blue')}
                    className='rounded-full text-white px-3 py-2 bg-blue-500 hover:bg-blue-700'>
                    Blue</button>
                <button onClick={() => setColor('red')}
                    className='rounded-full text-white px-3 py-2 bg-red-500 hover:bg-red-700'>
                    Red</button>
                <button onClick={() => setColor('green')}
                    className='rounded-full text-white px-3 py-2 bg-green-500 hover:bg-green-700'>
                    Green</button>
                <button onClick={() => setColor('orange')}
                    className='rounded-full text-white px-3 py-2 bg-orange-500 hover:bg-orange-700'>
                    Orange</button>
                <button onClick={() => setColor('pink')}
                    className='rounded-full text-white px-3 py-2 bg-pink-500 hover:bg-pink-700'>
                    Pink</button>
                <button onClick={() => setColor('violet')}
                    className='rounded-full text-white px-3 py-2 bg-violet-500 hover:bg-violet-700'>
                    Violet</button>
                <button onClick={() => setColor('purple')}
                    className='rounded-full text-white px-3 py-2 bg-purple-500 hover:bg-purple-700'>
                    Purple</button>
                <button onClick={() => setColor('yellow')}
                    className='rounded-full text-white px-3 py-2 bg-yellow-500 hover:bg-yellow-700'>
                    Yellow</button>
            </div>
        </div>
    );
}

export default BgChanger;