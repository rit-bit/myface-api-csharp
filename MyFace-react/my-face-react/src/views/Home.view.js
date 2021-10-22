import React, { useState, useEffect } from 'react';
import posts from './Test.data'

export function HomeView() {

    const [userPosts, setUserPosts] = useState();

    useEffect(() => {
            /*const res = await fetch("https://localhost:5001/posts");
            setTest(res.json());
            console.log(test);*/

            fetch("https://localhost:5001/posts")
                .then(response => {
                    // console.log("response: " + response)
                    return response.json()
                })
                .then(json => {
                    setUserPosts(CreateUsersAndAddPosts(json))
                })
                .catch(error => console.log("Error: " + error))
                .finally(()=>{
            })
    }, [])

    if (!userPosts) {
        return <p>
            Loading...
        </p>
    }
    // console.log(JSON.stringify(userPosts));
    return (
        <div className={"line-wrap-container"}>
            {Object.entries(userPosts).map(([key, value]) => {
                return <UserPostContainer key={"user: " + key} userdata={value} />
            })
            }
        </div>
    )
}

function UserPostContainer(props) {
    return (
        <div className={"user-profile align-centre"}>
            {console.log(JSON.stringify(props.userdata))}
            <UserProfile image={props.userdata.profileImage} name={props.userdata.name} />
            {props.userdata.posts.map((post, index) =>
                <UserRecentPost post={post} />)}
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

function UserRecentPost(props) {
    return (
        <div className="post-container card">
            {props.post.message}
        </div>
    )
}

function CreateUsersAndAddPosts(json){
    const users = {};
    json.items.map((post, index)=> {
        const id = json.items[index].postedBy.id;
        const name = json.items[index].postedBy.displayName;
        const profileImage = json.items[index].postedBy.profileImageUrl;
        // console.log("Id: " + id);
        // console.log("name: " + name);

        const postObject = {
            id: json.items[index].id,
            message: json.items[index].message,
            imageUrl: json.items[index].imageUrl,
            postedAt: json.items[index].postedAt,
        }

        if (users[id]){
            users[id].posts.push(postObject)
        }else{
            users[id] = {
                name: name,
                profileImage: profileImage,
                posts: [
                    postObject
                ]
            }
        }
    })
    // console.log("users length: " + users[81].posts.length);
    // console.log("user 1: " + users[2].name);
    // console.log("user 1 post: " + users[0].post[2].message);
    return users;
}

//


// const json = res.json();
// console.log(json);