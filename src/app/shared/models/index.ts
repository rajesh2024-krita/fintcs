
export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  user: User;
}

export interface User {
  id: string;
  username: string;
  role: string;
  edpNo?: string;
  name: string;
  email?: string;
  societyId?: string;
  societyName?: string;
}

export interface Society {
  id: string;
  name: string;
  address: string;
  city: string;
  phone?: string;
  fax?: string;
  email?: string;
  website?: string;
  registrationNo?: string;
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
  createdAt: Date;
}

export interface Member {
  id: string;
  memNo: string;
  name: string;
  fatherHusbandName?: string;
  officeAddress?: string;
  city?: string;
  phoneOffice?: string;
  branch?: string;
  phoneRes?: string;
  mobile?: string;
  designation?: string;
  residenceAddress?: string;
  dob?: Date;
  dojSociety?: Date;
  email?: string;
  dojOrg?: Date;
  dor?: Date;
  nominee?: string;
  nomineeRelation?: string;
  openingBalanceShare: number;
  value: number;
  crDrCd: string;
  bankName?: string;
  payableAt?: string;
  accountNo?: string;
  status: string;
  statusDate?: Date;
  deductions: string[];
  photoPath?: string;
  signaturePath?: string;
  societyId: string;
  societyName?: string;
  createdAt: Date;
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
  purpose?: string;
  authorizedBy?: string;
  paymentMode: string;
  bankId?: string;
  bankName?: string;
  chequeNo?: string;
  chequeDate?: Date;
  share: number;
  cd: number;
  lastSalary: number;
  mwf: number;
  payAmount: number;
  givenJson?: string;
  takenJson?: string;
  societyId: string;
  societyName?: string;
  createdAt: Date;
}

export interface LoanType {
  id: string;
  name: string;
  code: string;
}

export interface Bank {
  id: string;
  name: string;
  code: string;
}

export interface VoucherType {
  id: string;
  name: string;
  code: string;
}

export interface Voucher {
  id: string;
  voucherNo: string;
  voucherTypeId: string;
  voucherTypeName?: string;
  date: Date;
  chNo?: string;
  chequeDate?: Date;
  narration?: string;
  remarks?: string;
  passDate?: Date;
  societyId: string;
  societyName?: string;
  lines: VoucherLine[];
  totalDebit: number;
  totalCredit: number;
  createdAt: Date;
}

export interface VoucherLine {
  id: string;
  voucherId: string;
  particularsName: string;
  debit: number;
  credit: number;
  dbCr: string;
  ibldbc: number;
}

export interface MonthlyDemandHeader {
  id: string;
  monthId: string;
  monthName?: string;
  yearValue: number;
  totalAmount: number;
  totalMembers: number;
  societyId: string;
  societyName?: string;
  rows: MonthlyDemandRow[];
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

export interface Month {
  id: string;
  name: string;
  code: string;
}

export interface ApiResponse<T> {
  success: boolean;
  data: T;
  message?: string;
  errors?: string[];
}

export interface PaginatedResponse<T> {
  items: T[];
  totalCount: number;
  pageIndex: number;
  pageSize: number;
  totalPages: number;
}
