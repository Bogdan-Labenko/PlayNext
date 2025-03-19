import styles from '../styles/home.module.scss'
import BackgroundSpace from '../components/lotties/BackgroundSpace.jsx';
import LogInPlanet from '../components/lotties/LogInPlanet.jsx';

export default function Home() {
  return (
    <div>
      <div className={styles.start}>
        {/* <h1>Play-Next</h1> */}
        <img src='/logo_w.png' />
        <h2>Умные рекомендации для геймеров,<br/> которым надоели однотипные игры</h2>
        <BackgroundSpace></BackgroundSpace>
        {/* <LogInPlanet></LogInPlanet> */}
      </div>
    </div>);
}

