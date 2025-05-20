import { useEffect, useState } from "react"
import styles from "../styles/signUp.module.scss"
import Waiting from "./lotties/Waiting.jsx"
import { useRouter } from "next/navigation"
import { logout, setUser } from "../slices/userSlice.js";
import { useDispatch } from "react-redux";
import { revalidatePath } from "next/cache.js";

export default function SignUpLogInModal({ setIsModal }){
    const [isSelector, setIsSelector] = useState(false);

    const [email, setEmail] = useState('');
    const [nickname, setNickname] = useState('')
    const [password, setPassword] = useState('')
    const [message, setMessage] = useState('')
    
    const router = useRouter();

    const dispatch = useDispatch();

    const handleLogIn = async (e) => {
        e.preventDefault();
        
        const response = await fetch('http://localhost:5000/api/auth/login', {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, password }),
        });


        if (response.ok) {
            const data = await response.json();
            dispatch(setUser({ user: data.user }));
            router.refresh();
        } 
        else {
            const data = await response.json();
            setMessage(data.message || 'Something went wrong!');
        }
    };
    
    const handleSignUp = async (e) => {
        e.preventDefault();
    
        const response = await fetch('http://localhost:5000/api/auth/signup', {
          method: 'POST',
          credentials: 'include',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({ email, password, nickname}),
        });
    
        if (response.ok) {
            const data = await response.json();
            dispatch(setUser({ user: data.user }));
            setIsModal(false)
            router.push("/dashboard");
        } 
        else {
            const data = await response.json();
            setMessage(data.message || 'Something went wrong!');
        }
    };

    const changeSelector = (value) => {
        setEmail('');
        setNickname('');
        setPassword('');
        setIsSelector(value);
    }

    return (
        <div className={styles.container}>
            <div
                className={styles.background}
                onClick={() => setIsModal(false)}
            ></div>
            <div className={styles.window}>
                <div className={styles.switch}>
                    <div className={styles.logInButton} onClick={() => changeSelector(false)}>Log In</div>
                    <div className={styles.signUpButton} onClick={() => changeSelector(true)}>Sign Up</div>
                    <div className={`${styles.selector} ${isSelector ? styles.selectorActive : ""}`}></div>
                </div>
                <div className={styles.left}>
                    {isSelector ? "" : <div className={styles.logIn}>
                        <h2>Welcome back!<br />Log in to continue</h2>
                        <span>Email</span><br />
                        <input 
                            type="text"  
                            placeholder="example@mail.com"
                            onChange={(e) => setEmail(e.target.value)}
                            value={email}
                        />
                        <br />
                        <span>Password</span><br />
                        <input 
                            type="password" 
                            placeholder="Password"
                            onChange={(e) => setPassword(e.target.value)}
                            value={password}
                        />
                        <br />
                        <button onClick={handleLogIn}>Log in</button><br />
                        {message}
                    </div>}
                    {isSelector ? <div className={styles.signUp}>
                        <h2>Join us today! <br/> Sign up to get started</h2>
                        <span>Nickname</span><br />
                        <input 
                            type="text" 
                            placeholder="Nickname"
                            onChange={(e) => setNickname(e.target.value)}
                            value={nickname}
                        /><br />
                        <span>Email</span><br />
                        <input 
                            type="text" 
                            placeholder="example@mail.com"
                            onChange={(e) => setEmail(e.target.value)}
                            value={email}
                        />
                        <br />
                        <span>Password</span><br />
                        <input 
                            type="password" 
                            placeholder="Password"
                            onChange={(e) => setPassword(e.target.value)}
                            value={password}
                        />
                        <br />
                        <button onClick={handleSignUp}>Sign Up</button>
                        {message}
                    </div> : ""}
                </div>
                <div className={styles.right}>
                    <Waiting></Waiting>
                </div>
            </div>
        </div>
    )
}