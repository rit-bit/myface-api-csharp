import React, { useState, useEffect } from 'react';
// import users from './Test.data'

export function UserView() {

    const [users, setUsers] = useState({"items": []});

    useEffect(() => {
        try {
            //const res = await fetch("http://localhost:5001/posts")

            fetch("https://localhost:5001/posts")
                .then(response => response.json())
                .then(json => setUsers(json))
                .catch(error => console.log("Error: " + error))

            // const json = res.json();
            // console.log(json);
        } catch (error) {
            console.log("error: " + error)
        }
    }, [])

    return (
        <div className={"line-wrap-container"}>
            {users.items.map((user, index) =>
                <UserContainer key={"user: " + index} userdata={user} />
            )}
        </div>
    )
}

function UserContainer(props) {
    return (
        <div className={"user-profile align-centre"}>
            <UserProfile image={props.userdata.image} name={props.userdata.name} />
            {props.userdata.posts.map((post, index) =>
                <UserRecentPosts post={post} />)}
        </div>
    )
}

function UserProfile(props) {
    return (
        <div className="align-centre">
            <img src={props.image}
                className="card profile-image round-image" />
            <div className="profile-name">{props.name}</div>
        </div>
    )
}

function UserRecentPosts(props) {
    return (
        <div className="post-container card">
            {props.post.message}
        </div>
    )
}

//