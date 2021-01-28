import Vue from "vue";
import { GridPlugin, Toolbar } from "@syncfusion/ej2-vue-grids";
import { data} from './data'


Vue.use(GridPlugin);

export default Vue.extend({
    data: () => { 
        return {
            data: data,
            toolbarOptions: ['ExcelExport', 'PdfExport']
        };
    },
    methods: {
        toolbarClick(e: any) {
            if (e.item.id === 'Grid_excelexport') { // 'Grid_excelexport' -> Grid component id + _ + toolbar item name
                (this.$refs.grid as any).serverExcelExport('Home/ExcelExport');
            } else {
                (this.$refs.grid as any).serverExcelExport('Home/PdfExport');
            }

        }
    },
    provide: {
        grid: [Toolbar]
    }
});
