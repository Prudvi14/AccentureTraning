import React, { useState, useCallback, useEffect, useRef} from 'react';
import '../TailwindAndProps/style.css'


function PasswordGenerator() {
    const [length, setLength] = useState(8);
    const [number, setNumber] = useState(false);
    const [character, setCharacter] = useState(false);
    const [password, setPassword] = useState("");

    //useref
    const passwordRef=useRef(null);

    const passwordHandel = useCallback(
        () => {
            let pass = ""
            let str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            let num = "0123456789"
            let char = "!@#$%^&*_+~?-="
            if (number) str += num;
            if (character) str += char;

            for (let i = 1; i <= length; i++) {
                let char = Math.floor(Math.random() * str.length);
                pass += str.charAt(char);
            }

            setPassword(pass);
        },[length, number, character, setPassword]);


        const copytoClipboard=useCallback(()=>{
            window.navigator.clipboard.writeText(password);
        },[password]);

        useEffect(()=>{passwordHandel()},[length, number, character, passwordHandel]);

    return (
        <div className='w-full max-w-md mx-auto shadow-md rounded-lg px-4 py-3 my-8 bg-gray-800 text-orange-500 '
            style={{ backgroundColor: '#060606', textAlign: 'center' }}>
                <h1 className='text-white text-center my-3'>Password Generator</h1>
                <div className='flex-wrap shadow rounded-lg overflow-hidden'>
                    <input
                        type='text'
                        placeholder='Password'
                        value={password}
                        readOnly
                        ref={passwordRef}
                        className='bg-white text-black rounded-md p-2 mb-4 w-64'/>
                    <button 
                    onclick={copytoClipboard}
                    className='bg-blue-500 text-white rounded-md p-2 hover:bg-orange-600'>
                        copy
                    </button>
                </div>
                <div className='flex text-center gap-x-2'>
                    <div className='flex items-center gap-x-1'>
                        <input 
                        type="range"
                        min={6}
                        max={12}
                        value={length}
                        className='cursor-pointer'
                        onChange={(e)=>{setLength(e.target.value)}
                        }/>
                        <label>Length: {length}</label>
                    </div>
                    <div className='flex items-center gap-x-1'>
                        <input 
                        type="checkbox"
                        defaultChecked={number}
                        id='numberInput'
                        onChange={()=>{setNumber((prev)=>!prev);}}/>
                        <label htmlFor='numberInput'>Numbers</label>
                    </div>
                    <div className='flex items-center gap-x-1'>
                        <input 
                        type="checkbox"
                        defaultChecked={character}
                        id='characterInput'
                        onChange={()=>{setCharacter((prev)=>!prev);}}/>
                        <label htmlFor='characterInput'>Characters</label>
                    </div>
                </div>
        </div>
    );
}

export default PasswordGenerator;