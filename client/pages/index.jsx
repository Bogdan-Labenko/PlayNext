import styles from '../styles/home.module.scss'
import BackgroundSpace from '../components/lotties/BackgroundSpace.jsx';

export default function Home() {
  return (
    <div>
      <BackgroundSpace />
      <div className={styles.start}>
        <img src='/logo_w.png' />
        <h2>Smart Game Recommendations<br/> for True Gamers</h2>
      </div>
    </div>);
}

