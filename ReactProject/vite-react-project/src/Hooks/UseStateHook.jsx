import { useState } from 'react';

function UseStateHook() {
  let [counter, setCounter]=useState(0);
  let [fruit, setfruit] = useState("Apple");

  const add=()=>{
    if(counter<20) setCounter(counter+1);
  }
  const sub=()=>{
    if(counter>0) setCounter(counter-1);
  }
  const ChangeFruitName = () => {
        fruit="Grapes"
        setfruit(fruit);
        console.log(fruit);
  }
  return (
    <div align="center">
      <h1>Welcome to My App and its range is from 0-20</h1>
      <h1>value: {counter}</h1>
      <button onClick={add}>Add</button>
      <button onClick={sub}>subtract</button>
      <br/>
      <div><h3>{fruit}</h3></div>
      <button onClick={ChangeFruitName}>Change Fruit Name </button>
    </div>
  );
}

export default UseStateHook;