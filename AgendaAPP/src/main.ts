import 'primeflex/primeflex.css'
import 'primevue/resources/themes/aura-light-green/theme.css'
import 'primeicons/primeicons.css'

import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from 'primevue/config'
import Button from 'primevue/button'
import Divider from 'primevue/divider'
import InputText from 'primevue/inputtext'
import InputMask from 'primevue/inputmask'
import InputGroup from 'primevue/inputgroup'
import InputGroupAddon from 'primevue/inputgroupaddon'
import FloatLabel from 'primevue/floatlabel'
import ConfirmDialog from 'primevue/confirmdialog'
import ToastService from 'primevue/toastservice'
import Toast from 'primevue/toast'
import ConfirmationService from 'primevue/confirmationservice'
import Dialog from 'primevue/dialog'
import IconField from 'primevue/iconfield'
import InputIcon from 'primevue/inputicon'

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
app.component('InputGroup', InputGroup)
app.component('InputGroupAddon', InputGroupAddon)
app.component('IconField', IconField)
app.component('InputIcon', InputIcon)
app.component('FloatLabel', FloatLabel)
app.component('Toast', Toast)
app.component('ConfirmDialog', ConfirmDialog)
app.component('Dialog', Dialog)
app.component('DataTable', DataTable)
app.component('Column', Column)
