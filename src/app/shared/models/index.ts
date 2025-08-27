
export interface Society {
  id: string;
  name: string;
  address: string;
  city: string;
  phone: string;
  fax: string;
  email: string;
  website: string;
  registrationNo: string;
  interestDividend: number;
  interestOD: number;
  interestCD: number;
  interestLoan: number;
  interestEmergencyLoan: number;
  interestLAS: number;
  limitShare: number;
  limitLoan: number;
  limitEmergencyLoan: number;
  chBounceChargeAmount: number;
  chBounceChargeMode: string;
}

export interface AppUser {
  id: string;
  role: string;
  edpNo: string;
  name: string;
  addressO: string;
  addressR: string;
  designation: string;
  phoneO: string;
  phoneR: string;
  mobile: string;
  email: string;
  username: string;
  societyId: string;
  societyName?: string;
}

export interface Member {
  id: string;
  memNo: string;
  name: string;
  fatherHusbandName: string;
  officeAddress: string;
  city: string;
  phoneOffice: string;
  branch: string;
  phoneRes: string;
  mobile: string;
  designation: string;
  residenceAddress: string;
  dob: Date;
  dojSociety: Date;
  email: string;
  dojOrg: Date;
  dor: Date;
  nominee: string;
  nomineeRelation: string;
  openingBalanceShare: number;
  value: number;
  crDrCd: string;
  bankName: string;
  payableAt: string;
  accountNo: string;
  status: string;
  statusDate: Date;
  deductions: string[];
  photoUrl?: string;
  signatureUrl?: string;
  societyId: string;
  societyName?: string;
}

export interface Loan {
  id: string;
  loanNo: string;
  loanTypeId: string;
  loanTypeName?: string;
  loanDate: Date;
  edpNo: string;
  name: string;
  loanAmount: number;
  prevLoan: number;
  netLoan: number;
  installments: number;
  installmentAmount: number;
  purpose: string;
  authorizedBy: string;
  paymentMode: string;
  bankId: string;
  bankName?: string;
  chequeNo: string;
  chequeDate: Date;
  share: number;
  cd: number;
  lastSalary: number;
  mwf: number;
  payAmount: number;
  givenMembers: any[];
  takenMembers: any[];
  societyId: string;
}

export interface MonthlyDemandHeader {
  id: string;
  monthId: string;
  monthName?: string;
  yearValue: number;
  societyId: string;
  totalMembers: number;
  totalAmount: number;
  createdAt: Date;
}

export interface MonthlyDemandRow {
  id: string;
  headerId: string;
  edpNo: string;
  memberName: string;
  loanAmt: number;
  cd: number;
  loan: number;
  interest: number;
  eLoan: number;
  interestExtra: number;
  net: number;
  intDue: number;
  pInt: number;
  pDed: number;
  las: number;
  int: number;
  lasIntDue: number;
}

export interface Voucher {
  id: string;
  voucherNo: string;
  voucherTypeId: string;
  voucherTypeName?: string;
  date: Date;
  chNo: string;
  chequeDate: Date;
  narration: string;
  remarks: string;
  passDate: Date;
  totalDebit: number;
  totalCredit: number;
  societyId: string;
  lines: VoucherLine[];
}

export interface VoucherLine {
  id: string;
  voucherId: string;
  particulars: string;
  debit: number;
  credit: number;
  dbCr: string;
  ibldbc: number;
}

export interface LookupItem {
  id: string;
  name: string;
  code?: string;
  value?: any;
}

export interface PaginatedResult<T> {
  data: T[];
  total: number;
  page: number;
  pageSize: number;
  totalPages: number;
}

export interface ApiResponse<T> {
  success: boolean;
  data: T;
  message: string;
  errors?: string[];
}
