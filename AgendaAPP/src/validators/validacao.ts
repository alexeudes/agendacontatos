import { required, email, helpers } from '@vuelidate/validators'

const validacoes = {
  nome: { required: helpers.withMessage('O nome é obrigatório', required) },
  email: { email: helpers.withMessage('Informe um e-mail válido.', required) },
  telefone: { required: helpers.withMessage('O telefone é obrigatório', required) }
}

export { validacoes }
