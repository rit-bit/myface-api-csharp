// HomeView
//  - [selectedUser, setSelectedUser] = useState(null)
//  - User A
//      - Profile modal
//      - Posts
//          - Post 1
//          - Post 2
//  - User B
//      - Profile modal
//      - Posts
//          - Post 3
//          - Post 4

import React, {useState, useEffect, useContext} from 'react';
import {UserModal} from "./partial/UserModal.partial";

// const userModalContext = React.createContext({
//     DisplayModal: () => DisplayModal()
// })

function DisplayModal() {
    // setUserModalState(true);
    console.log("Clicked");
}

export function HomeView() {

    const [userPosts, setUserPosts] = useState();
    const [userModalState, setUserModalState] = useState(false);

    const [selectedUser, setSelectedUser] = useState(null);

    useEffect(() => {
        fetch("https://localhost:5001/posts")
            .then(response => {
                // console.log("response: " + response)
                return response.json()
            })
            .then(json => {
                setUserPosts(CreateUsersAndAddPosts(json))
            })
            .catch(error => console.log("Error: " + error))
            .finally(() => {
            })
    }, [])

    if (!userPosts) {
        return <p>
            Loading...
        </p>
    }

    return (
        // <userModalContext.Provider>
        <>
            <div className={"line-wrap-container"}>
                {Object.entries(userPosts).map(([key, value]) => {
                    return <UserPostContainer onclick key={"user: " + key} userdata={value} setSel={() => setSelectedUser(key)}/>
                })
                }
            </div>
            <UserModal userId={selectedUser} onClose={() => setSelectedUser(null)}/>
        </>
        // </userModalContext.Provider>
    )
}

function UserPostContainer(props) {
    const twoPosts = props.userdata.posts.slice(0, 2);
    return (
        <div className={"user-profile align-centre"}>
            <UserProfile image={props.userdata.profileImage} name={props.userdata.name} setSel={props.setSel}/>
            {twoPosts.map((post, index) =>
                <UserRecentPost post={post}/>)}
        </div>
    )
}

function UserProfile(props) {
    // const userModalContext = useContext(userModalContext);
    return (
        <div className="align-centre">
            <img onClick={props.setSel} src={props.image}
                 className="card profile-image round-image"/>
            <div className="profile-name">{props.name}</div>
        </div>
    )
}

function UserRecentPost(props) {
    return (
        <div className="post-container card">
            {props.post.message.length > 60 ? props.post.message.substring(0, 60).trim() + "..." : props.post.message}
        </div>
    )
}

function CreateUsersAndAddPosts(json) {
    const users = {};
    json.items.map((post, index) => {
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

        if (users[id]) {
            users[id].posts.push(postObject)
        } else {
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