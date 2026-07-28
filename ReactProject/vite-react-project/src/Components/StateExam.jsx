import { useState } from 'react';

function StateExam()
{
	let [fruit, setFruit] = useState("Banana");  //State
	// let [count, setCount] = useState(0);
	// let [display, setDisplay] = useState(true);
	// let handleClick = () => {
	// 	setFruit("Mango");
	// }
 
	// let handleToggleClick = () => {
	// 	setFruit(fruit === "Banana" ? "Mango" : "Banana");
	// }
 
	return (	
			<div>
			{/* {fruit === "Banana" ? <h1>Fruit is Banana</h1> : <h1>Not a Banana</h1>} */}
			<h1>{ fruit}</h1>
 
			{/* {fruit === "Banana" ? (<button onClick={() => setFruit("Mango")} >Change Fruit</button>) : */}
				{/* (<button onClick={() => setFruit("Banana")} >Change Fruit</button>)} */}
 
			{/* <button onClick={handleClick} >Change Fruit 1</button> */}
 
			{/* <button onClick={handleToggleClick} >Change Fruit2</button> */}
 
			{/* <hr /> */}
 
			{/* <h1>Counter Value : {count}</h1> */}
			{/* <button onClick={() => setCount(count + 1)}>Update Counter</button> */}
 
			{/* <hr /> */}
			{/* { display ?<h1>David</h1> :<h1>Hidden</h1>} */}
			{/* <button onClick={() => setDisplay(!display)}>Toggle Display</button> */}
 
 
		</div>
	)
 
}