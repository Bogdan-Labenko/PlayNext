"use client";

import Lottie from "lottie-react";
import anim from "/public/lotties/background.json"

export default function Anim(){
    return(
        <div style={{zIndex: "-10", position: "fixed", inset: "0"}}>
            <Lottie animationData={anim} loop={true} />
        </div>
    )
}