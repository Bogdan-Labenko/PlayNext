"use client";

import Lottie from "lottie-react";
import anim from "/public/lotties/loader2.json";

export default function HandLoader(){
    return (
        <div style={{
                position: 'fixed',
                top: '50%',
                left: '50%',
                transform: 'translate(-50%, -50%)'
            }}>
            <Lottie animationData={anim} loop={true}/>
        </div>
    )
}