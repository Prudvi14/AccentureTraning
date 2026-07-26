import { useState } from 'react';

function App() {
  let [counter, setCounter]=useState(0);
  const add=()=>{
    if(counter<20) setCounter(counter+1);
  }
  const sub=()=>{
    if(counter>0) setCounter(counter-1);
  }
  return (
    <div align="center">
      <h1>Welcome to My App and its range is from 0-20</h1>
      <h1>value: {counter}</h1>
      <button onClick={add}>Add</button>
      <button onClick={sub}>subtract</button>
    </div>
  );
}

export default App;