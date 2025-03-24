import { useState } from 'react'
import styles from '../styles/navbar.module.scss'
import SignUpLogInModal from './SignUpLogInModal.jsx'
import { useSelector } from 'react-redux';

export default function NavBar(){
    const [isHovered, setIsHovered] = useState(false);
    const [isModal, setIsModal] = useState(false);

    const user = useSelector((state) => state.user.user);
    
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
                <a href="/">
                    <div className={styles.iconWrapper}>
                        {/* "Стандартная" иконка */}
                        <img
                            className={`${styles.icon} ${isHovered ? styles.hidden : ''}`}
                            src="/home_thin.png"
                            alt="Home"
                        />
                        {/* Иконка при наведении */}
                        <img
                            className={`${styles.icon} ${isHovered ? '' : styles.hidden}`}
                            src="/home.png"
                            alt="Home"
                        />
                    </div>
                </a>
                <a href="/recommendations">
                    <div className={styles.iconWrapper}>
                        <img
                            className={`${styles.icon} ${isHovered ? styles.hidden : ''}`}
                            src="/trend_thin.png"
                            alt="Recommendations"
                        />
                        <img
                            className={`${styles.icon} ${isHovered ? '' : styles.hidden}`}
                            src="/trend.png"
                            alt="Recommendations"
                        />
                    </div>
                </a>
            </div>
            <div className={styles.div3}>
                {
                user ? <div>
                        <a 
                            className={styles.avatar} 
                            href="/dashboard"
                        >
                            <img src="avatar.jpg" alt="Avatar" />
                        </a>
                    </div>
                : <div className={styles.logIn} onClick={() => {
                        setIsModal(!isModal)
                    }}>
                    <div className={styles.iconWrapper}>
                        <img
                            className={`${styles.icon} ${isHovered ? styles.hidden : ''}`}
                            src="/enter_thin.png"
                            alt="Log in"
                        />
                        <img
                            className={`${styles.icon} ${isHovered ? '' : styles.hidden}`}
                            src="/enter.png"
                            alt="Log in"
                        />
                    </div>
                </div>}
            </div>
            
        </header>   
        {isModal ? <SignUpLogInModal setIsModal={setIsModal} /> : ""}
    </>
}