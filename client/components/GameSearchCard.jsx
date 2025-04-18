import ColorThief from 'colorthief'
import { useEffect, useRef, useState } from 'react'
import { cover_big, no_cover_big,  } from '../constants/urls.js';
import styles from '../styles/gameSearchCard.module.scss';
import { platformMap } from '../constants/platformMap';
import Color from 'color';


export default function GameSearchCard({ game }){
    const [mainColor, setMainColor] = useState();
    const [altColor, setAltColor] = useState();
    const imgRef = useRef(null);

    const hasXbox = game.platforms?.some(p => platformMap.Xbox.includes(p.id));
    const hasPC = game.platforms?.some(p => platformMap.PC.includes(p.id));
    const hasPS = game.platforms?.some(p => platformMap.PlayStation.includes(p.id));
    
    const darken = (color, factor) => {
        return color.map(c => Math.max(0, Math.floor(c * factor)))
    }

    // useEffect(() => {
    //     const img = imgRef.current
    //     if (!img) return
      
    //     img.crossOrigin = 'Anonymous'
    //     img.onload = () => {
    //       const colorThief = new ColorThief()
    //       const result = colorThief.getColor(img) // [r, g, b]
      
    //       const main = Color.rgb(result)
    //       const brightness = main.luminosity()  // 0 (чёрный) … 1 (белый)
      
    //       // на сколько мы миксуем: 0.3 = 30% чёрного/белого, 70% основного
    //       const mixRatio = 0.12
      
    //       let alt
    //       if (brightness < 0.05) {
    //         // слишком тёмный → чуть осветлим
    //         alt = main.mix(Color('white'), mixRatio)
    //       } else {
    //         // всё остальное → затемним
    //         alt = main.mix(Color('black'), mixRatio)
    //       }
      
    //       setMainColor(main.rgb().string())
    //       setAltColor(alt.rgb().string())
    //     }
    //   }, [])

    useEffect(() => {
        const img = imgRef.current
        if (!img) return
      
        img.crossOrigin = 'Anonymous'
        img.onload = () => {
          const colorThief = new ColorThief()
          const result = colorThief.getColor(img) // [r, g, b]
      
          // 1) Получаем основной цвет
          let main = Color.rgb(result)
          const mainLum = main.luminosity()  // 0 (чёрный) … 1 (белый)
      
          // 2) Если основной цвет слишком яркий, слегка его затемняем:
          const brightThreshold = 0.6      // порог «слишком ярко»
          const brightMixRatio = 0.3     // насколько миксовать с чёрным
          if (mainLum > brightThreshold) {
            main = main.mix(Color('black'), brightMixRatio)
          }
      
          // 3) Высчитываем фон для текста (altColor):
          const darkThreshold = 0.05
          const mixRatio = 0.25          // для alt всегда 30% «черного/белого» компонента
          let alt
          if (main.luminosity() < darkThreshold) {
            // слишком тёмный → осветляем
            alt = main.mix(Color('white'), mixRatio - 0.15)
          } else {
            // обычное затемнение
            alt = main.mix(Color('black'), mixRatio )
          }
      
          setMainColor(main.rgb().string())  // например, "rgb(220, 180, 50)" или чуть темнее
          setAltColor(alt.rgb().string())    // тёмный/светлый фон для текста
        }
      }, [])

    return <div style={{backgroundColor: mainColor}} className={styles.gameCard}>
        <div className={styles.left}>
            <div>
                <img ref={imgRef} src={game.cover?.imageId ? `${cover_big}${game.cover?.imageId}.jpg` : no_cover_big} alt="cover" />
            </div>
        </div>
        <div className={styles.right}>
            <div style={{backgroundColor: altColor}} className={styles.title}>
                <h2>{game.name}</h2>
            </div>
            <div style={{backgroundColor: altColor}} className={styles.genres}>
                <h3>Genres</h3>
                <div>
                    {game?.genres[0]?.name
                        && <p>{game.genres[0].name}</p>}
                    {game?.genres[1]?.name
                        && <p>{game.genres[1].name}</p>}
                </div>
            </div>
            <div style={{backgroundColor: altColor}} className={styles.platforms}>
                <h3>Platforms</h3>
                <div>
                    <span>
                        <img className={hasPC ? '' : styles.inactive} src='Windows.png' alt="PC cover" />
                    </span>
                    <span>
                        <img className={hasXbox ? '' : styles.inactive} src='Xbox.png' alt="Xbox cover" />
                    </span>
                    <span>
                        <img className={hasPS ? '' : styles.inactivePs} src='PlayStation.png' alt="PlayStation cover" />
                    </span>
                </div>
            </div>
        </div>
    </div>
}