import { useState } from "react"
import styles from "../styles/signIn.module.scss"
import Waiting from "./lotties/Waiting.jsx"

export default function SignUpLogInModal({ setIsModal }){
    const [isSelector, setIsSelector] = useState(false);
    return(
    <>
        <div 
            className={styles.background}
            onClick={() => setIsModal(false)}
        ></div>
        <div className={styles.window}>
            <div className={styles.switch}>
                <div className={styles.logInButton} onClick={() => setIsSelector(false)}>Log In</div>
                <div className={styles.signUpButton} onClick={() => setIsSelector(true)}>Sign Up</div>
                <div className={`${styles.selector} ${isSelector ? styles.selectorActive : ""}`}></div>
            </div>
            <div className={styles.left}>
                {isSelector ? "" : <div className={styles.logIn}>
                    Email<input type="text"/><br />
                    Password<input type="text"/>
                </div>}
                {isSelector ? <div className={styles.signUp}>
                    Nickname<input type="text"/><br />
                    Email<input type="text"/><br />
                    Password<input type="text"/>
                </div> : ""}
            </div>
            <div className={styles.right}>
                <Waiting></Waiting>
            </div>
        </div>
    </>
    )
}