import 'primevue/resources/themes/aura-light-green/theme.css'
import 'primeicons/primeicons.css'

import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config'
import Button from 'primevue/button'
import Divider from 'primevue/divider'
import InputText from 'primevue/inputtext'
import InputMask from 'primevue/inputmask'
import Toast from 'primevue/toast'
import ConfirmDialog from 'primevue/confirmdialog'
import ToastService from 'primevue/toastservice'
import ConfirmationService from 'primevue/confirmationservice'

import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import router from './route/route'

const app = createApp(App)
app.use(router)
app.use(PrimeVue)
app.use(ToastService)
app.use(ConfirmationService)
app.mount('#app')

app.component('Button', Button)
app.component('Divider', Divider)
app.component('InputText', InputText)
app.component('InputMask', InputMask)
app.component('Toast', Toast)
app.component('ConfirmDialog', ConfirmDialog)
app.component('DataTable', DataTable)
app.component('Column', Column)
