import http from "k6/http";

export let options = {
    stages: [
        { duration: "10s", target: 500 },
        { duration: "30s", target: 500 },
    ],
    insecureSkipTLSVerify: true,
};
export default function () {
    const res = http.get("https://localhost:50001/WeatherForecast");
}
