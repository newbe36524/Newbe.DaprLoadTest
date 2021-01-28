import http from "k6/http";

export let options = {
  stages: [
    { duration: "10s", target: 100 },
    { duration: "30s", target: 100 },
  ],
  insecureSkipTLSVerify: true,
};
export default function () {
  const res = http.get(
    "http://localhost/dh/WeatherForecastDaprHttp?port=3500&appId=newbe-normalaspnetcore&methodName=WeatherForecast"
  );
}
