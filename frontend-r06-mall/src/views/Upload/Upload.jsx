import React, { useState } from 'react'
import axios from 'axios'

const Upload = () => {
    const [image, setImage] = useState("");

    const uploadImage = () => {
        const formData = new FormData();
        formData.append("file", image);
        formData.append("upload_preset", "nrxqvf2q");

        axios.post(`https://api.cloudinary.com/v1_1/ddeipl7ed/image/upload`, formData
        ).then(res => {
            console.log("upload thanh cong")
            console.log(res)
            setImage(res.data.url)
        }).catch(err => {
            console.log(err)
        })
    }
    return (
        <div>
            <input type="file"
                onChange={e => { setImage(e.target.files[0]) }} />
            <button onClick={uploadImage}>Upload</button>
            <img src={image} alt="" />
        </div>
    )
}

export default Upload
