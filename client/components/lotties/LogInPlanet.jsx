"use client";

import Lottie from "lottie-react";
import anim from "/public/lotties/sign_up_anim.json";

export default function LottieAnimation(){
    return (
        <div className="">
            <Lottie animationData={anim} loop={true}/>
        </div>
    )
}