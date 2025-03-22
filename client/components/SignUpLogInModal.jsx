import { useEffect, useState } from "react"
import styles from "../styles/signIn.module.scss"
import Waiting from "./lotties/Waiting.jsx"

export default function SignUpLogInModal({ setIsModal }){
    const [isSelector, setIsSelector] = useState(false);

    return (
        <div className={styles.container}>
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
                        <h2>Welcome back!<br />Log in to continue</h2>
                        <span>Email</span><br />
                        <input type="text" placeholder="example@mail.com"/><br />
                        <span>Password</span><br />
                        <input type="text" placeholder="Password"/><br />
                        <button>Log in</button>
                    </div>}
                    {isSelector ? <div className={styles.signUp}>
                        <h2>Join us today! <br/> Sign up to get started</h2>
                        <span>Nickname</span><br />
                        <input type="text" placeholder="Nickname"/><br />
                        <span>Email</span><br />
                        <input type="text" placeholder="example@mail.com"/><br />
                        <span>Password</span><br />
                        <input type="text" placeholder="Password"/><br />
                        <button>Sign up</button>
                    </div> : ""}
                </div>
                <div className={styles.right}>
                    <Waiting></Waiting>
                </div>
            </div>
        </div>
    )
}