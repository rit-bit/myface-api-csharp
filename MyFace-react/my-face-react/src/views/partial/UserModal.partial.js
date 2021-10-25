import react from 'react';
import { UserProfile } from '../Home.view';

// "4" == 4  -->  true
// "4" === 4 -->  false

// false, 0, "", null, undefined, []  -->  false
// true, 1, "e", [1, 2, 2] --> true


export function UserModal(props){
    if (props.user === null){
        return <div></div>
    }
    // console.log("User ", JSON.stringify(props.user));
    return(
        <div onClick={props.onClose} id="myModal" className="modal">
            <div onClick={(e) => e.stopPropagation()} className="modal-content">
                <span onClick={props.onClose} className="close">&times;</span>
                <UserProfile image={props.user.profileImage} name={props.user.name}/>
                <p className={"align-centre"}>{props.user.email}</p>
                <UserPostsWithDetails posts={props.user.posts} />
            </div>

        </div>
    )
}

function UserPostsWithDetails(props) {
    console.log("Posts: ", JSON.stringify(props.posts))
    return(
        <div>
            {props.posts.map(post => (
                <UserPostWithDetail post={post} />
            ))}
        </div>
    );
}

function UserPostWithDetail(props) {
    console.log("Post: ", JSON.stringify(props.post))
    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: "numeric", minute: "numeric" };

    return(
        <div className={"user-post-with-detail"}>
            <img className={"user-post-image"} src={props.post.imageUrl} alt="" width={360}/>
            <div className={"user-post-content"}>
                <p>{props.post.message}</p>
                <p className={"user-post-date"}>{new Date(Date.parse(props.post.postedAt)).toLocaleString("en-UK", options)}</p>
            </div>
        </div>
    );
}