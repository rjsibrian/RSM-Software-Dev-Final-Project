<template>
  <div class="q-pa-md">
    <q-table
      flat bordered
      :rows="filteredRows"
      :columns="columns"
      color="primary"
      row-key="id"
      class="table-cotainer"
    >
      <template v-slot:top-left>
        <q-input borderless dense debounce="300" v-model="filter" placeholder="Search by Product Name">
          <template v-slot:append>
            <q-icon name="search" />
          </template>
        </q-input>
      </template>
      <template v-slot:top-right>
        <q-btn
          class="export-csv-btn"
          icon-right="archive"
          label="Export to CSV"
          no-caps
          @click="exportCsv"
        />
        <q-btn
          class="export-pdf-btn"
          icon-right="picture_as_pdf"
          label="Export to PDF"
          no-caps
          @click="exportPdf"
        />
      </template>
    </q-table>
  </div>
</template>

<script>
import { ref, computed } from 'vue'
import { exportFile, useQuasar } from 'quasar'
import axios from 'axios'
import { jsPDF } from 'jspdf'
import 'jspdf-autotable'

export default {
  setup() {
    const $q = useQuasar()

    const columns = [
      { name: 'id', align: 'left', label: 'id', field: 'id', sortable: true },
      { name: 'orderID', align: 'left', label: 'Order ID', field: 'orderID', sortable: true },
      { name: 'orderDate', align: 'center', label: 'Order Date', field: 'orderDate', sortable: true },
      { name: 'productName', align: 'center', label: 'Product Name', field: 'productName' },
      { name: 'productCategory', align: 'center', label: 'Product Category', field: 'productCategory' },
      { name: 'unitPrice', align: 'center', label: 'Unit Price', field: 'unitPrice', sortable: true },
      { name: 'orderQty', align: 'center', label: 'Order Qty', field: 'orderQty', sortable: true },
      { name: 'lineTotal', align: 'center', label: 'Line Total', field: 'lineTotal', sortable: true },
      { name: 'salesPersonName', align: 'center', label: 'Sales Person', field: 'salesPersonName' },
      { name: 'shippingAddress', align: 'center', label: 'Shipping Address', field: 'shippingAddress' },
      { name: 'billingAddress', align: 'center', label: 'Billing Address', field: 'billingAddress' },
    ];

    const rows = ref([]);
    const filter = ref('');

    async function fetchData() {
      try {
        const response = await axios.get('http://localhost:5243/api/SalesSummaryView', {
          params: { productName: filter.value }
        });
        rows.value = response.data;
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    }

    function exportCsv() {
      const content = [columns.map(col => wrapCsvValue(col.label))].concat(
        rows.value.map(row => columns.map(col => wrapCsvValue(
          typeof col.field === 'function' ? col.field(row) : row[col.field === void 0 ? col.name : col.field],
          col.format,
          row
        )))
      );

      const status = exportFile(
        'table-export.csv',
        content.join('\r\n'),
        'text/csv'
      );

      if (status !== true) {
        $q.notify({
          message: 'Browser denied file download...',
          color: 'negative',
          icon: 'warning'
        })
      }
    }

    function exportPdf() {
      const doc = new jsPDF('l', 'pt'); // 'l' para orientación horizontal

      // Título de la tabla
      doc.setFontSize(18);
      doc.setTextColor(40);
      doc.text('Sales Summary', 40, 30);


      const head = [columns.map(col => ({ content: col.label, styles: { fillColor: [111, 92, 195] } }))];

      doc.autoTable({
        head,
        body: rows.value.map(row => columns.map(col => col.field === 'function' ? col.field(row) : row[col.field])),
        margin: { top: 60 }, // Margen superior
        columnStyles: { 0: { cellWidth: 40 } }, // Ancho de la primera columna
      });
      doc.save('table-export.pdf');
    }

    function wrapCsvValue(val, formatFn, row) {
      let formatted = formatFn !== void 0
        ? formatFn(val, row)
        : val

      formatted = formatted === void 0 || formatted === null
        ? ''
        : String(formatted)

      formatted = formatted.split('"').join('""')

      return `"${formatted}"`
    }

    fetchData();

    // Filtrar las filas basadas en el término de búsqueda
    const filteredRows = computed(() => {
      return rows.value.filter(row => row.productName.toLowerCase().includes(filter.value.toLowerCase()));
    });

    return {
      columns,
      filteredRows,
      exportCsv,
      exportPdf,
      filter
    }
  }
}
</script>

<style scoped>
.table-cotainer{
  border-radius: 10px; 
  padding: 20px;
  border: 1px solid transparent; 
  background-color: #ffffff;
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1); 
}

.export-csv-btn {
  background-color: #26B560; 
  color: white;
}

.export-pdf-btn {
  background-color: #6F5CC3; 
  color: white;
  margin-left: 10px; 
}
</style>
