import { useEffect, useRef } from "react";
import ColorThief from "colorthief";

export default function Recomendations() {
  // const imgRef = useRef(null); // Правильный useRef

  // useEffect(() => {
  //   const img = new Image();
  //   img.src = "/response_gta.jpeg";
  //   img.crossOrigin = "anonymous";

  //   img.onload = () => {
  //     try {
  //       const colorThief = new ColorThief();
  //       const color = colorThief.getColor(img);

  //       // Вычисляем контрастный цвет для текста
  //       const brightness = (color[0] * 299 + color[1] * 587 + color[2] * 114) / 1000;

  //       const adjustedColor = adjustBrightness(color, brightness > 128 ? -10 : 10);

  //       console.log("Dominant Color:", color);
  //       console.log("Secondary Color:", adjustedColor);
  //       console.log("Text Color:", brightness > 128 ? "black" : "white");
  //     } catch (error) {
  //       console.error("Error extracting color:", error);
  //     }
  //   };
  // }, []);

  // const adjustBrightness = (rgb, amount) => {
  //   return rgb.map(channel => Math.min(255, Math.max(0, channel + amount)));
  // };


  // return (
  //   <div>
  //     <h2>Recomendations</h2>
  //     <img
  //       ref={imgRef}
  //       src="/response.jpeg"
  //       alt="Game Cover"
  //       crossOrigin="anonymous" // Важно для работы с изображениями с другого домена
  //     />
  //   </div>
  // );\
  return <></>
}
