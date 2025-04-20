"use client";

import Lottie from "lottie-react";
import anim from "/public/lotties/loader1.json";

export default function Loader(){
    return (
        <div style={{width: '5%', height: '10vh', margin: '0 auto', marginBottom: '10vh'}}>
            <Lottie animationData={anim} loop={true}/>
        </div>
    )
}