import React from 'react'
import './style.css'

function ProfileCard({name, age, gender}) {
    return(
        <div align='center' className='text-center'>
            <h1>Name: {name}</h1>
            <h1>Age: {age}</h1>
            <h1>Gender: {gender}</h1>
        </div>
    );
}
export default ProfileCard;