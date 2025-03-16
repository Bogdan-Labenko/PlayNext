import { useState } from 'react'
import styles from '../styles/navbar.module.scss'

export default function NavBar(){
    const [isHovered, setIsHovered] = useState("/home_thin.png");

    return <>
        <header
            className={styles.navbar}
            onMouseEnter={() => setIsHovered(true)}  // Когда навели на navbar
            onMouseLeave={() => setIsHovered(false)} // Когда убрали курсор
        >
            <div className={styles.div1}>
                <div>
                    <img className={styles.logo} src="/logo_t.png" alt="logo" />
                </div>
            </div>
            <div className={styles.div2}>
                {/* <a href="/">
                    <img
                        className={styles.icon}
                        src={isHovered ? "/home.png" : "/home_thin.png"}
                        alt="Home"
                    />
                </a>
                <a href="/recomendations">
                    <img
                        className={styles.icon}
                        src={isHovered ? "/trend.png" : "/trend_thin.png"}
                        alt="Home"
                    />
                </a> */}

                <a href="/">
                    <div className={styles.iconWrapper}>
                        {/* "Стандартная" иконка */}
                        <img
                        className={`${styles.icon} ${isHovered ? styles.hidden : ''}`}
                        src="/home_thin.png"
                        alt="Home default"
                        />
                        {/* Иконка при наведении */}
                        <img
                        className={`${styles.icon} ${isHovered ? '' : styles.hidden}`}
                        src="/home.png"
                        alt="Home hover"
                        />
                    </div>
                </a>
                <a href="/recomendations">
                    <div className={styles.iconWrapper}>
                        <img
                        className={`${styles.icon} ${isHovered ? styles.hidden : ''}`}
                        src="/trend_thin.png"
                        alt="Recommendations default"
                        />
                        <img
                        className={`${styles.icon} ${isHovered ? '' : styles.hidden}`}
                        src="/trend.png"
                        alt="Recommendations hover"
                        />
                    </div>
                </a>
            </div>
            <div className={styles.div3}>

            </div>
        </header>   
    </>
}