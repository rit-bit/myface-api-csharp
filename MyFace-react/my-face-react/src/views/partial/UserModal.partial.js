import react from 'react';

// "4" == 4  -->  true
// "4" === 4 -->  false

// false, 0, "", null, undefined, []  -->  false
// true, 1, "e", [1, 2, 2] --> true


export function UserModal(props){
    if (props.userId === null){
        return <div></div>
    }
    return(
        <div onClick={props.onClose} id="myModal" className="modal">
            <div onClick={(e) => e.stopPropagation()} className="modal-content">
                <span onClick={props.onClose} className="close">&times;</span>
                <p>Some text in the Modal..</p>
            </div>

        </div>
    )
}