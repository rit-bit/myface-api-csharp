import React from 'react';
import users from './Test.data'

export function UserView() {
    // user = GEtAPI()
    return (
        <div className={"line-wrap-container"}>
            {users.map((user, index) =>
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
            <UserRecentPosts post={post}/>)}
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
    return(
        <div className="post-container card">
                {props.post.message}
        </div>
    )
}

//