import React from 'react';

const users = [
    {
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles Alexis"
    },
    {
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles Alexis Alexis"
    },
    {
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles Alexis"
    },{
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles"
    },{
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles Alexis"
    },
    {
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles Alexis"
    },
    {
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles Alexis Alexis"
    },
    {
        image: 'https://media.istockphoto.com/photos/portrait-of-a-smiling-man-of-indian-ethnicity-picture-id1277971635?b=1&k=20&m=1277971635&s=170667a&w=0&h=L1pgfiauaN2wIOgxdetel63XLq2ax3EkbfaIUT67USc=',
        name: "charles Alexis"
    },



]

export function UserView(){
    // user = GEtAPI()
    return(
        <div className={"line-wrap-container"}>
            {users.map((user, index) =>
                <User key={"user: " + index} image={user.image} name={user.name}/>
            )}
        </div>
    )
}

function User(props){
    return(
        <div className={"user-profile"}>
        <img src={props.image}
             className="card profile-image round-image"/>
    <div className="profile-name">{props.name}</div>
        </div>
    )
}

//