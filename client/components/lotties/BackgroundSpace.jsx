"use client";

import Lottie from "lottie-react";
import anim from "/public/lotties/background.json"

export default function BackgroundVideo() {
    return (
      <video
        autoPlay
        muted
        loop
        playsInline
        style={{
          position: "fixed",
          top: 0,
          left: 0,
          width: "100vw",
          height: "100vh",
          objectFit: "cover",
          zIndex: -10,
          pointerEvents: "none",
        }}
      >
        <source src="/background_trimmed.webm" type="video/webm" />
      </video>
    );
  }