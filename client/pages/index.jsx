import styles from '../styles/home.module.scss'
import BackgroundSpace from '../components/lotties/BackgroundSpace.jsx';
import LogInPlanet from '../components/lotties/LogInPlanet.jsx';

export default function Home() {
  return (
    <div>
      <div className={styles.start}>
        <img src='/logo_w.png' />
        <h2>Smart Game Recommendations<br/> for True Gamers</h2>
        <BackgroundSpace></BackgroundSpace>
      </div>
    </div>);
}

