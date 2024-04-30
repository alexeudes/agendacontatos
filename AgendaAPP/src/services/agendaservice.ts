import axios from 'axios'

const agendaService = axios.create({
  baseURL: 'https://localhost:7068/api'
})

export { agendaService }
