import http from 'k6/http'
import { check } from 'k6'

export const options = {
  vus: 10,
  duration: '1m',
  thresholds: {
    http_req_duration: ['p(99)<10'],
  },
};

export default () => {
  const res = http.get('http://localhost:5000/service/1');

  check(res, {
    'is status 200': (r) => r.status === 200,
  });
};
